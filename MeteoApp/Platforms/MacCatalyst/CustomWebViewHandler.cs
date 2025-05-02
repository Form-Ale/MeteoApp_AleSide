using Foundation;
using WebKit;
using Microsoft.Maui.Handlers;

namespace MeteoApp;

public class CustomWebViewHandler : WebViewHandler
{
    protected override void ConnectHandler(WKWebView platformView)
    {
        base.ConnectHandler(platformView);

        platformView.Configuration.UserContentController.AddScriptMessageHandler(
            new ScriptMessageHandler(this), "invokeAction");
    }

    private class ScriptMessageHandler : NSObject, IWKScriptMessageHandler
    {
        private readonly CustomWebViewHandler _handler;

        public ScriptMessageHandler(CustomWebViewHandler handler)
        {
            _handler = handler;
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            var payload = message.Body.ToString();
            _handler.VirtualView?.Handler?.Invoke(payload);
        }
    }
}