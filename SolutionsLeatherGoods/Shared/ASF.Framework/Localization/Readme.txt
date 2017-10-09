
Forma de Uso y Recomendaciones:

1)Añadir el namespace de la localización en ASF.UI.WbSite\Views\Web.config:

  <system.web.webPages.razor>
    <host factoryType="System.Web.Mvc.MvcWebRazorHostFactory, System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" />
    <pages pageBaseType="System.Web.Mvc.WebViewPage">
      <namespaces>
        <add namespace="ASF.Framework.Localization"/>
      </namespaces>
	</pages>
	</system.web.webPages.razor>
