<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Tikoze.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--REAL CODE STARTS HERE-->

    <div class="container">
        <div class="row">

            <!--CONTENT PANEL-->
            <div class="col-sm-8">

                <!--SEARCH--> 
                <div class="form-group form-group-lg form-horizontal"> 
                    <label class="col-sm-2 control-label sr-only" for="formGroupInputLarge">Search</label> 
                    <div class="row"> 
                        <div class="col-sm-10"> 
                            <asp:TextBox ID="searchBox" runat="server" CssClass="form-control"></asp:TextBox> 
                            <div> 
                                <asp:RadioButtonList ID="searchOptions" runat="server" RepeatDirection="Horizontal"> 
                                    <asp:ListItem Text="Song Title" Value="0" Selected="True"> </asp:ListItem> 
                                    <asp:ListItem Text="Lyrics" Value="1"> </asp:ListItem> 
                                    <asp:ListItem Text="Artist" Value="2"> </asp:ListItem> 
                                    <asp:ListItem Text="Album" Value="3"> </asp:ListItem> 
                                </asp:RadioButtonList> 
                            </div> 
                        </div> 
                        <div class="col-sm-2"> 
                            <asp:Button ID="searchButton" runat="server" Text="Search" Cssclass ="btn btn-success" OnClick="Search_Click" /> 
                        </div> 
                    </div> 
                </div><!--End Search-->



                <!--START SONG DISPLAY DIV-->
                <div class="container">

                    <!--DISPLAY SHARING LINKS TO SOCIAL MEDIA-->
                    <div runat="server" class="container" id="share">
                        <span class="btn-default" id="facebook">Facebook</span>
                        <span class="btn-default" id="twitter">Twitter</span>
                        <span class="btn-default" id="Instagram">Instagram</span>
                        <span class="dl-horizontal"></span>
                        <span class="" id="link"><code>www.tikoze.com/Display?artist=default&album=default&song=default</code></span>
                    </div><!--End share div-->

                    <!--DISPLAY SONG METADATA-->
                    <div runat="server" class="container" id="songMetaDataDisplay">

                    </div><!--End song metadata div-->

                    <!--DISPLAY LYRICS VERIFICATOIN-->
                    <div runat="server" class="container" id="lyricsVerificationDisplay">

                    </div><!--End lyrics verification-->

                    <!--DISPLAY BODY OF SONG-->
                    <div runat="server" class="container" id="songBodyDisplay">

                    </div><!--End body of song-->

                    <!--DISPLAY SONG FOOTER INFO-->
                    <div runat="server" class="container" id="songFooterDisplay">

                    </div><!--End footer info-->

                </div><!--End song display div-->

            </div><!--End content panel div-->

            <!--START SIDE PANEL-->
            <div class="col-sm-4">
                <div class="col-sm-12">
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
                <div class="col-sm-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/D8B422104CAC38F6FD84DA8614BD38C671C6">
                </div><!--end ad div-->
                <div class="col-sm-12">
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
                <div class="col-sm-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/SNP_2922281_en_v1">
                </div><!--end ad div-->

            </div><!--end right-side-panel-->
        </div><!--end row-->
    </div><!--end container-->
</asp:Content>
