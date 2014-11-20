<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Tikoze.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--REAL CODE STARTS HERE-->

    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <asp:Literal ID="searchResults" runat="server" Text="this is the search results literal"></asp:Literal>
                <br />
                <asp:Literal ID="addSongMessage" runat="server" Text="Didn't find what you were looking for? Add it &raquo;"></asp:Literal>
                <br />
                <asp:Literal ID="searchNavigation" runat="server" Text="First Previous Next Last"></asp:Literal>
            </div>
            <div class="col-md-4">
                <div class="col-md-12">
                    <hgroup>
                        <h3>5 Most Popular Songs</h3>
                    </hgroup>
                    <ol>
                        <li>Song Title number 1</li>
                        <li>Second Song Title</li>
                        <li>Song Title numero 3</li>
                        <li>This is Song Title number 4</li>
                        <li>View Song Title #5 </li>
                    </ol>
                </div>
                <div class="col-md-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/D8B422104CAC38F6FD84DA8614BD38C671C6" height="auto">
                </div><!--end ad div-->
                <div class="col-md-12">
                    <hgroup>
                        <h3>5 Most Shared Songs</h3>
                    </hgroup>
                    <ol>
                        <li>Song Title number 1</li>
                        <li>Second Song Title</li>
                        <li>Song Title numero 3</li>
                        <li>This is Song Title number 4</li>
                        <li>View Song Title #5 </li>
                    </ol>
                </div>
                <div class="col-md-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/SNP_2922281_en_v1" height="auto">
                </div><!--end ad div-->

            </div><!--end right-side-panel-->
        </div><!--end row-->
    </div><!--end container-->
</asp:Content>
