import { AglPetsModule } from './agl-pets.module';

describe('AglPetsModule', () => {
  let aglPetsModule: AglPetsModule;

  beforeEach(() => {
    aglPetsModule = new AglPetsModule();
  });

  it('should create an instance', () => {
    expect(aglPetsModule).toBeTruthy();
  });
});
