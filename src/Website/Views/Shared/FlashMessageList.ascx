<%@ Control Language="C#" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="CRIneta.Model"%>
<%@ Import Namespace="System.Collections.Generic"%>
<%@ Import Namespace="MvcContrib"%>


<% 
    var flashMessages = (IEnumerable<FlashMessage>)ViewData.Model;
    if (flashMessages.Count<FlashMessage>() > 0)
    {
%>
<div id="messageContainer">
    <ul class="messagesList">
        <%= GetFlashMessages() %>
    </ul>
</div>
<%
    } 
%>


<script runat="server">
    
    private string GetFlashMessages()
    {
        StringBuilder builder = new StringBuilder();
        
        var flashMessages = (IEnumerable<FlashMessage>)ViewData.Model;
        foreach (var message in flashMessages)
        {
            string css = string.Empty;
            switch (message.Type)
            {
                case FlashMessage.MessageType.Message:
                    css = "flash message";
                    break;
                case FlashMessage.MessageType.Error:
                    css = "flash error";
                    break;
            }

            builder.AppendFormat("<li class=\"{0}\">{1}</li>", css, message.Message);
        }

        return builder.ToString();
    }
</script>
