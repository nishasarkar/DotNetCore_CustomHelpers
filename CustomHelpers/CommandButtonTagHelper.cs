using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Lab_CustomHelpers.CustomHelpers
{
    public class CommandButtonTagHelper:TagHelper
    {
        [HtmlAttributeName("value")] public string Value { get; set; }
        [HtmlAttributeName("class")] public string CssClass { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        { string strHtml = $"<button type='submit' name='command' class='{CssClass}'>{Value}</button>";
            output.Content.SetHtmlContent(strHtml);
        }
    }
}
/*
 An explanation for the above code: 
-----------------------------------------
1> The [HtmlTargetElement] attribute indicates that the custom Tag helper name which will be available on the HTML page ie.,
command-button.

➢ The [HtmlAttributeName] attribute indicates the attribute values for the custom Tag helper ie., value and class for Value and CssClass properties respectively. 
➢ In the Process() method, During runtime we are constructing the Html button of type submit with the class value of the button control would be set from the CssClass and Value attributes of the command-button Tag helper which we will be using in the Login.cshtml
➢ Let us use this command-button Tag helper in the Login.cshtml instead of
<input> tag for Create button. <input type="submit" value="Create" class="btn btn-primary" /> 
Above <input> is replaced with the below two lines of code :   
<command-button class="btn btn-primary" value="Login"></command-button>               
<command-button class="btn btn-warning" value="Cancel"></command-button> 
During Runtime, the value which is assigned to the command-button Tag helper attributes class and value will be available in the Properties of the CommandButtonTagHelper class ie.,
CssClass Value respectively.
In the Process() method, The Button HTML control is constructed with these values and the corresponding CSS style will be displayed for the Login and Cancel buttons on the Login page. 
 
➢ Let us run the application. Once the application is loaded successfully, click on the Login link to redirect it to the Login page. 

 */
