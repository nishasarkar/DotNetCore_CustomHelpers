using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace Lab_CustomHelpers.CustomHelpers
{
    [HtmlTargetElement(Attributes = "asp-active-link")]
    public class ActiveRouteTagHelper: TagHelper
    {
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var currentController = ViewContext.RouteData.Values["Controller"].ToString();
            var currentAction = ViewContext.RouteData.Values["Action"].ToString();
            var tagController = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-controller").Value.ToString();
            var tagAction = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-action").Value.ToString();
            if (currentController == tagController.ToString() && currentAction == tagAction.ToString())
            { var existingCss = context.AllAttributes.FirstOrDefault(a => a.Name == "class").Value.ToString();
              var cssClass = context.AllAttributes.FirstOrDefault(a => a.Name == "asp-active-link").Value.ToString();
                output.Attributes.SetAttribute("class", $"{existingCss} {cssClass}"); 
            }
        }
    }
}
/*
 
 An explanation for the above code: ➢
--------------------------------------------
We have created this custom Tag helper to create the custom attribute with the name “aspactive-link” to highlight the “link” by using the CSS class “active”.
Hence, we are adding the [HtmlTargetElement (Attributes = "asp-active-link")] to the ActiveLinkTagHelper class. 
➢ The TagHelper class has a virtual method Process (). 
we will override it to Synchronously execute our custom tag helper ie., ActiveLinkTagHelper. 
➢ We have created the property called ViewContext of type ViewContext and decorated the property with an attribute [ViewContext]. 
It Specifies that a tag helper property ie., ViewContext property should be set with the current View Details while creating the tag helper.
But this property should not be bound as an attribute to the tag helper so the property is decorated with [HtmlAttributeNotBound] as given below.
[HtmlAttributeNotBound]      
[ViewContext]
public ViewContext ViewContext { get; set; } 

In the Process () method, we are fetching the current controller and action details from the ViewContext property and comparing it with the current HTML tag helper controller and action details,
if both are equal then we are setting the value of the class attribute of the Author tag<a> to the custom attribute “asp-active-link” to set the active style to highlight the currently executing page during runtime.

➢ Let us overwrite the  <link rel="stylesheet" href="~/Lab_CustomHelpers.styles.css" asp-append-version="true"/>" in the _layout.cshtml with the internal CSS class .
active as given below :    
<style>        
.active 
{           
color: red ! important;       
}    
</style> 
➢ Use this class in the Author tag<a> with the attribute as “asp-active-link” and
set the value to “active” so it should get the internal CSS style if the current tag helper values match with the current executing values  asp-active-link="active" 
 
 ➢  run the application and when the home page loads successfully, the “Home” link would be highlighted . 
 Privacy link is highlighted when the Privacy page loads successfully 
➢ Login link is highlighted when the Login page loads successfully
 
 */
