using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;

namespace XFramework.Client.Shared.Core.Features.Cache;

public partial class CacheState
{
    protected class ClearStateHandler : ActionHandler<ClearState>
    {
        private CacheState CurrentState => Store.GetState<CacheState>();
        
        public ClearStateHandler(IConfiguration configuration, ISessionStorageService sessionStorageService, ILocalStorageService localStorageService, SweetAlertService sweetAlertService, NavigationManager navigationManager, EndPointsModel endPoints, IHttpClient httpClient, HttpClient baseHttpClient, IJSRuntime jsRuntime, IMediator mediator, IStore store) : base(configuration, sessionStorageService, localStorageService, sweetAlertService, navigationManager, endPoints, httpClient, baseHttpClient, jsRuntime, mediator, store)
        {
            Configuration = configuration;
            SessionStorageService = sessionStorageService;
            LocalStorageService = localStorageService;
            SweetAlertService = sweetAlertService;
            NavigationManager = navigationManager;
            EndPoints = endPoints;
            HttpClient = httpClient;
            BaseHttpClient = baseHttpClient;
            JsRuntime = jsRuntime;
            Mediator = mediator;
            Store = store;
        }

        public override async Task<Unit> Handle(ClearState action, CancellationToken aCancellationToken)
        {
            try
            {
                StateHelper.ClearProperties(action, CurrentState);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Unit.Value;
        }
    }
}