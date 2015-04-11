<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Tikoze.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <hgroup class="title">
            <h1><%: Title %></h1>
            <h2> Tikoze: Your Haitian lyrics web app</h2>
        </hgroup>

        <div class="col-md-10">
            <article>
                <p>        
                    Hello folks! My name is Jacques W. Pluviose, a software developer based out of Deltona, Florida. 
                </p>
                <p>
                    This project intends to create a crowd-sourced repository of data about Haitian music. There is a HUGE need for this service,
                    but it is virtually non-existent.
                </p>
                <p>
                    So, will you join us in our journey by contributing? <a href="Add.aspx" type="button" class="btn-success">Add a song &raquo;</a>
                </p>
            </article>

            <aside>
                <h3>Navigation</h3>
                <p>        
                    See the site.
                </p>
                <ul>
                    <li><a runat="server" href="~/">Home</a></li>
                    <li><a runat="server" href="~/About">About</a></li>
                    <li><a runat="server" href="~/Contact">Contact</a></li>
                </ul>
            </aside>
        </div>
    </div>
    
</asp:Content>