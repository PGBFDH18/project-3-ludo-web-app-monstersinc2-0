using Microsoft.Extensions.Logging;
using WebApp.Controllers;
using WebApp.Models.ApplicationModel;
using WebApp.Models.BindingModel;
using Xunit;

namespace WebAppTests
{
    public class LudoControllerTests
    {
        ILogger _log = ILogger<LudoController>();

        [Fact]
        public void Index_ReturnsIndexViewModelInViewResult()
        {
            var ludoController = new LudoController(new LudoGameAPIProccessor(), new PlayerFormExtractor(), ILogger<LudoController>)
    }
    }
