<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Tikoze.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--REAL CODE STARTS HERE-->
    <div class="container">

        <!--Search-->
        <div class="form-group form-group-lg form-horizontal">
            <label class="col-sm-2 control-label sr-only" for="formGroupInputLarge">Search</label>
            <div class="row">
                <div class="col-md-10">
                    <asp:TextBox ID="searchBox" runat="server" CssClass="form-control"></asp:TextBox>
                    <div>
                        <asp:RadioButton ID="songNameRB" runat="server" CssClass="radio-inline" Checked="True" Text="Song Name" GroupName="searchOptions" />
                        <asp:RadioButton ID="songLyricsRB" runat="server" CssClass="radio-inline" Checked="False" Text="Lyrics" GroupName="searchOptions" />
                        <asp:RadioButton ID="artistNameRB" runat="server" CssClass="radio-inline" Checked="False" Text="Artist" GroupName="searchOptions" />
                        <asp:RadioButton ID="musicalReleaseNameRB" runat="server" CssClass="radio-inline" Checked="False" Text="Album" GroupName="searchOptions" />
                    </div>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="searchButton" runat="server" Text="Search" Cssclass ="btn btn-success" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
        <!--End Search-->

        <!--CONTENT panel-->

        <div class="row">
            <div class="col-md-8">
                
                <!--SEARCH RESULTS-->
                <div class="container">
                    <asp:Literal ID="searchResults" runat="server"></asp:Literal>
                </div><!--end search results-->

                <!--ADD SONG MESSAGE-->
                <div class="container">
                    <asp:Literal ID="addSongMessage" runat="server" Visible="false"></asp:Literal>
                </div><!--end Add Song Message-->
                
                <!--SEARCH NAVIGATION-->
                <div class="container">
                    <asp:Literal ID="searchNavigation" runat="server">
                        <span class='btn btn-default col-sm-2'>First</span> 
                        <span class='btn btn-default col-sm-2'>Previous</span> 
                        <span class='btn btn-default col-sm-2'>Next</span>
                        <span class='btn btn-default col-sm-2'>Last</span>
                    </asp:Literal>
                </div><!--end search results navigation-->
                
                
                

            </div><!--end content panel-->

            <!--START right-side-panel-->
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
                    <img src="//storage.googleapis.com/support-kms-prod/D8B422104CAC38F6FD84DA8614BD38C671C6">
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
                    <img src="//storage.googleapis.com/support-kms-prod/SNP_2922281_en_v1">
                </div><!--end ad div-->

            </div><!--end right-side-panel-->

        </div><!--end row-->

    </div><!--end container-->
</asp:Content>
