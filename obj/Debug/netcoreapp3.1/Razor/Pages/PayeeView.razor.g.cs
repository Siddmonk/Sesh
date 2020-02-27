#pragma checksum "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9943d7b40c104c675211bf67c742192931be6a4f"
// <auto-generated/>
#pragma warning disable 1591
namespace Sesh.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Sesh;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\Projects\personal\Budget\Sesh\_Imports.razor"
using Sesh.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
using Sesh.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
using SeshDB.Data.Sesh;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/payeeview")]
    public partial class PayeeView : OwningComponentBase<TransactionService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Weather forecast</h1>\r\n\r\n");
            __builder.AddMarkupContent(1, "<p>This component demonstrates fetching data from a service.</p>\r\n\r\n");
#nullable restore
#line 19 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
 if (payees == null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(2, "    ");
            __builder.AddMarkupContent(3, "<p><em>Loading...</em></p>\r\n");
#nullable restore
#line 22 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, "    ");
            __builder.OpenElement(5, "table");
            __builder.AddAttribute(6, "class", "table");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.AddMarkupContent(8, "<thead>\r\n            <tr>\r\n                <th>Payee Id</th>\r\n                <th>Payee Name</th>\r\n                <th>User Name</th>\r\n            </tr>\r\n        </thead>\r\n        ");
            __builder.OpenElement(9, "tbody");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 34 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
             foreach (var payee in payees)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                ");
            __builder.OpenElement(12, "tr");
            __builder.AddMarkupContent(13, "\r\n                    ");
            __builder.OpenElement(14, "td");
            __builder.AddContent(15, 
#nullable restore
#line 37 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
                         payee.PayeeId

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n                    ");
            __builder.OpenElement(17, "td");
            __builder.AddContent(18, 
#nullable restore
#line 38 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
                         payee.PayeeName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n                    ");
            __builder.OpenElement(20, "td");
            __builder.AddContent(21, 
#nullable restore
#line 39 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
                         payee.UserName

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n");
#nullable restore
#line 41 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(24, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n");
#nullable restore
#line 44 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 46 "F:\Projects\personal\Budget\Sesh\Pages\PayeeView.razor"
       
    //AuthenticationState is available as a CascadingParameter

    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    List<Payees> payees;

    protected override async Task OnInitializedAsync()
    {
        // Get the current user
        var user = (await authenticationStateTask).User;
        // Get the budgeted items for the current user
        // We access BudgetServices using @Service
        payees = await @Service.GetPayeesAsync(user.Identity.Name);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
