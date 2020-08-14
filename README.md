# AGL Programming challenge

The solution has a **micro service architecture**.

It consists of

*   An **ASPNET Core 3.1 Web API** back end micro service
*   An **Angular 10 CLI app** front end UI

### ASPNET Core 3.1 Web API - Back end

The API has

*   an Entity project
    *   This contains the Entities used in the API.

*   a Repository project
    *   This contains
        
        *   a Pets Repository
            *   This uses HttpClient to fetch the pets and their owners. It uses **Newtonsoft.Json** to deserialize the data. 
            *   This Repository is injected into the Pets Manager.

*   a Business Logic project
    *   This contains
        
        *   a Pets Manager
            *   This uses LINQ to extract the pets by pet type and owner's gender from the data. 
            *   This Pets Manager is injected into the Controller.            

* an ASPNET Core 3.1 Web API project
    *   This contains
        
        *   a Pets Controller
            *   This contains a GET API called petsbypersongender.

                | API | Verb | Route | Sample Url |
                | ---------- | -------- | --------- | ----------- |
                | petsbypersongender | GET | /api/Pets/petsbypersongender | http://localhost:44373/api/Pets/petsbypersongender/2 |

            *   The API calls into the injected Pets Manager.                

*   an Unit Test project
    *   This contains unit tests for the Business Logic. **NSubstitute** is used to mock the Repository layer.  

**The Web API response JSON is like:**

```javascript
{
  "petsByPersonGender": [
    {
      "gender": 0,
      "pets": [
        {
          "name": "Garfield",
          "type": 2
        },
        {
          "name": "Jim",
          "type": 2
        },
        {
          "name": "Max",
          "type": 2
        },
        {
          "name": "Tom",
          "type": 2
        }                
      ]
    },
    {
      "gender": 1,
      "pets": [
        {
          "name": "Garfield",
          "type": 2
        },
        {
          "name": "Simba",
          "type": 2
        },
        {
          "name": "Tabby",
          "type": 2
        }        
      ]
    }
  ]
}
```

### Angular 10 CLI app - UI front end

The app has

*   Models mirroring the API response.    

*   a Service called Pets Service (in **TypeScript**) which
    
    *   calls the API using HttpClient.
    *   is injected into the Component.

*   a Component called agl-pets which

    *   calls the API using the injected Pets Service.
    *   displays the cats by owner's gender.  


**UI Screenshot:**

![Screenshot](https://github.com/VeritasSoftware/AGLCodingTest/blob/master/agl-ui/Screenshot.JPG)


**Development Environments:**

| Component | Environment |
| ------- | ------ |
| ASPNET Core 3.1 Web API | Visual Studio 2019 |
| Angular 10 CLI app | Visual Studio Code |

The Angular 10 app has been tested with Node v 14.8.0.