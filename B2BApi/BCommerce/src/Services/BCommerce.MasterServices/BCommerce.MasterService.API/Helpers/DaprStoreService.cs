namespace BCommerce.MasterService.API.Helpers
{
    public class DaprStoreService
    {
        private const string StateStoreName = "statestore";
        private readonly DaprClient _daprClient;

        public DaprStoreService(DaprClient daprClient)
        {
            _daprClient = daprClient;
            Handle();
        }

        public async Task Handle()
        {
            //var state = await _daprClient.GetStateEntryAsync<EditSupplierDto>(StateStoreName, supplier.Id.ToString());
            //state.Value = supplier;

            //await state.SaveAsync();

            //_daprClient.GetStateAsync<GetSuppliersDto>(StateStoreName, supplierId);
        }
    }
}