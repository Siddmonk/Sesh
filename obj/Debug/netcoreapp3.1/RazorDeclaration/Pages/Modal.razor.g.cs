// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Sesh.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Sesh;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using Sesh.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/home/upstatelloyd/Projects/Sesh/_Imports.razor"
using MatBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "/home/upstatelloyd/Projects/Sesh/Pages/Modal.razor"
using Sesh.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/upstatelloyd/Projects/Sesh/Pages/Modal.razor"
using SeshDB.Data.Sesh;

#line default
#line hidden
#nullable disable
    public partial class Modal : OwningComponentBase<TransactionService>
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 68 "/home/upstatelloyd/Projects/Sesh/Pages/Modal.razor"
       
    // TODO See if context can be passed when this component is called
    [Parameter]
    public EventCallback<string> ComponentDataUpdated { get; set; }
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    Dictionary<int, string> accountDict;
    Dictionary<int, string> payeeDict;
    Dictionary<int, string> catDict;

    protected override async Task OnInitializedAsync()
    {
        // Get the current user
        var user = (await authenticationStateTask).User;
        // Get a Dictionary of User Accounts
        accountDict = await @Service.GetAccountKeyValuesAsync(user.Identity.Name);
        // Get a Dictionary of Payees
        payeeDict = await @Service.GetPayeeKeyValuesAsync(user.Identity.Name);
        // Get a Dictionary of Categories
        catDict = await @Service.GetCatKeyValuesAsync(user.Identity.Name);
    }

    Transactions objTransaction = new Transactions();
    bool ShowPopup = false;
    void ClosePopup()
    {
        ShowPopup = false;
    }
    void AddNewTransaction()
    {
        objTransaction = new Transactions();
        // Set Id to 0 so we know it is a new record
        objTransaction.TransactionId = 0;
        ShowPopup = true;
    }
    async Task SaveTransaction()
    {
        ShowPopup = false;
        var user = (await authenticationStateTask).User;
        // New transaction will have Id set to 0
        if (objTransaction.TransactionId == 0)
        {
            //create new transaction
            Transactions objNewTransaction = new Transactions();
            objNewTransaction.AccountId = objTransaction.AccountId;
            objNewTransaction.TransactionDate = System.DateTime.Now;
            objNewTransaction.PayeeId = objTransaction.PayeeId;
            objNewTransaction.ItemId = objTransaction.ItemId;
            objNewTransaction.Memo = objTransaction.Memo;
            objNewTransaction.DebitAmount = objTransaction.DebitAmount;
            objNewTransaction.CreditAmount = objTransaction.CreditAmount;
            objNewTransaction.UserName = user.Identity.Name;

            var result = @Service.CreateTransactionAsync(objNewTransaction);
        }
        else
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 125 "/home/upstatelloyd/Projects/Sesh/Pages/Modal.razor"
                                                      
        }
        InvokeCallBack();
    }

    async Task InvokeCallBack()
    {
        await ComponentDataUpdated.InvokeAsync("");
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
