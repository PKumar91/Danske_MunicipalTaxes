namespace AppLibrary
{
    public interface IMunicipalityTaxesService
    {
        string GetMunicipalityTaxesDetails();
        string InsertMunicipalityTaxesDetails();
    }

    public class MunicipalityTaxesService : IMunicipalityTaxesService
    {
        private readonly IMunicipalityTaxesRepository _repository;
        
        public MunicipalityTaxesService(IMunicipalityTaxesRepository repo)
        {
            this._repository = repo;
        }

        public string GetMunicipalityTaxesDetails()
        {
            return this._repository.Load();
        }

        public string InsertMunicipalityTaxesDetails()
        {
            return this._repository.Insert();
        }
    }
}