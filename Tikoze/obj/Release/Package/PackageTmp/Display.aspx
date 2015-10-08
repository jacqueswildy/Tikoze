<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Tikoze.Display" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--REAL CODE STARTS HERE-->

    <div class="container">  
              
            <div class="row"><!--SEARCH-->

                <div runat="server" class="col-xs-8">
                    <div runat="server" class="row form-group form-group-lg form-horizontal"> 
                        <label class="col-xs-2 control-label sr-only" for="formGroupInputLarge">Search</label> 
                        <div class="row"> 
                            <div class="col-xs-10"> 
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
                            <div class="col-xs-2"> 
                                <asp:Button ID="searchButton" runat="server" Text="Search" Cssclass ="btn btn-success" OnClick="Search_Click" /> 
                            </div> 
                        </div> 
                    </div><!--End Search-->
                </div><!--End Search column-->           
            </div><!--End Search row-->

        <div class="row">
            
            <div class="col-lg-8"><!--CONTENT PANEL-->

                <div runat="server" class="row" id="share"><!--DISPLAY SHARING LINKS TO SOCIAL MEDIA-->                    
                    <div runat="server" id="fb" class="col-xs-12" style="padding-bottom:2%;">
                        <button class="btn btn-default" id="facebook">Facebook</button>                        
                        <button class="btn btn-default" id="twitter">Twitter</button>                        
                        <button class="btn btn-default" id="Instagram">Instagram</button>
                        <button class="btn btn-default" id="Google+">Google+</button>
                    </div><!--End social media div-->
                        
                    <div runat="server" class="row">
                        <div runat="server" id="link" class="col-xs-12">
                            <input name="link" value="www.tikoze.com/Display?artist=default&album=default&song=default" readonly class="col-xs-10"/>                                
                        </div><!--End link div-->
                    </div><!--wrapper to make sure the link goes on its own line-->
                </div><!--End share row -->       
                
                <!--START SONG DISPLAY DIV-->
                <div class="col-sm-12">

                    <div runat="server" class="row">
                        <!--DISPLAY SONG METADATA-->
                        <div runat="server" class="col-sm-8" id="songMetaDataDisplay"></div><!--End song metadata div-->
                    </div>                    

                    <div runat="server" class="row">
                        <!--DISPLAY LYRICS VERIFICATION-->
                        <div runat="server" class="col-sm-8" id="lyricsVerificationDisplay"></div><!--End lyrics verification-->
                    </div>                                
                                        
                    <div runat="server" class="row">
                        <!--DISPLAY BODY OF SONG-->
                        <div runat="server" class="col-xs-12" id="songBodyDisplay"></div><!--End body of song-->
                    </div>
                                        
                    <div runat="server" class="row">
                        <!--DISPLAY SONG FOOTER INFO-->
                        <div runat="server" class="col-sm-8" id="songFooterDisplay"></div><!--End song footer info-->
                    </div>                                                    

                </div><!--End song display div-->

            </div><!--End content panel div-->

            
            <div class="col-lg-4"><!--START SIDE PANEL-->
                <div runat="server" class="col-xs-12" id="chart1" style="background-color:whitesmoke;"></div>
                <div class="col-xs-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/D8B422104CAC38F6FD84DA8614BD38C671C6">
                </div><!--end ad div-->
                <div runat="server" class="col-xs-12" id="chart2" style="background-color:whitesmoke;"></div>
                <div class="col-xs-12">
                    <hgroup>
                        <h3>Advertising</h3>
                    </hgroup>
                    <img src="//storage.googleapis.com/support-kms-prod/SNP_2922281_en_v1">
                </div><!--end ad div-->

            </div><!--end right-side-panel-->
        </div><!--end row-->
    </div><!--end container-->
</asp:Content>
