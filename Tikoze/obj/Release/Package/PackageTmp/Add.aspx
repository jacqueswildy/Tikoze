<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Tikoze.Add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <!--REAL CODE STARTS HERE-->

    <div class="container">

        <!--START PROGRESS BAR-->
        <div  class="row">
            <div class="col-xs-12 progress">
                <div runat="server" id="divForStyle" class="progress-bar progress-bar-success" style="width:20%;">
                    <span runat="server" class="sr-only" id="progressBarSR">20% Complete</span>
                </div>
            </div>
        </div><!--End progress bar-->

        <!--START WIZARD-->
        <div class="row">

            <div id="startWizard" class="container-fluid">
                <HeaderTemplate><div runat="server"><h1>Add A New Song</h1></div></HeaderTemplate>
                <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" OnNextButtonClick ="Wizard1_NextButtonClick" 
                    OnFinishButtonClick="Wizard1_FinishButtonClick1">
                    <WizardSteps>
                        <asp:WizardStep ID="WizardStep1" runat="server" Title="Step 1 - Artist Info">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="aNameTextBoxLabel" runat="server" Text="Band/Artist Name:" AssociatedControlID="aNameTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="aNameTextBox" runat="server" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="aNameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="aNameTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 1st Row-->
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="mTypeOfTextBoxLabel" runat="server" Text="Type of Artist <em>(Band or Solo)</em>:" AssociatedControlID="mTypeOfTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="mTypeOfTextBox" runat="server" MaxLength="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="mTypeOfTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="mTypeOfTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 2st Row-->
                            </table>
                            <asp:Label ID="stepValidation1" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep2" runat="server" Title="Step 2 - Album Info">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="mRNameTextBoxLabel" runat="server" Text="Album Name:" AssociatedControlID="mRNameTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="mRNameTextBox" runat="server" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="mRNameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="mRNameTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 1st Row-->
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="mRTypeOfTextBoxLabel" runat="server" Text="Type of Release&lt;em&gt;(Album or Single)&lt;/em&gt;:" AssociatedControlID="mRTypeOfTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="mRTypeOfTextBox" runat="server" MaxLength="6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="mRTypeOfTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="mRTypeOfTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 2nd Row-->
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="mRYearReleasedTextBoxLabel" runat="server" Text="Year Released:" AssociatedControlID="mRYearReleasedTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="mRYearReleasedTextBox" runat="server" MaxLength="4"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="mRYearReleasedTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="mRYearReleasedTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 3rd Row-->
                            </table>
                            <asp:Label ID="stepValidation2" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep3" runat="server" Title="Step 3 - Song Info">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="sNameTextBoxLabel" runat="server" Text="Song Name: " AssociatedControlID="sNameTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="sNameTextBox" runat="server" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="sNameTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" 
                                            ControlToValidate="sNameTextBox" Display="Dynamic" Text="*Required" ForeColor="Red">
                                        </asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 1st Row-->
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="sTrackTextBoxLabel" runat="server" Text="Track Number:" AssociatedControlID="sTrackTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="sTrackTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr><!--End of 2nd Row-->
                            </table>
                            <asp:Label ID="stepValidation3" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep4" runat="server" Title="Step 4 - Add Lyrics">
                            <table class="auto-style1">
                                <tr>
                                    <td class="auto-style2">
                                        <asp:Label ID="sLyricsTextBoxLabel" runat="server" Text="Song Lyrics:" AssociatedControlID="sLyricsTextBox"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="sLyricsTextBox" runat="server" Height="600px" TextMode="MultiLine" Width="550px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="sLyricsTextBoxRequiredFieldValidator" runat="server" ErrorMessage="*Required" ControlToValidate="sLyricsTextBox" Display="Dynamic" Text="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr><!--End of 1st Row-->
                            </table>
                        </asp:WizardStep>
                        <asp:WizardStep ID="WizardStep5" runat="server" Title="Step 5 - Preview">
                            <table class="auto-style3">
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 1st Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label4" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 2nd Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label5" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label6" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 3rd Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label7" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 4th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label9" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label10" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 5th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label11" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 6th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label13" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 7th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label15" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label16" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 8th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label17" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label18" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 9th Row-->
                                <tr>
                                    <td class="auto-style4">
                                        <asp:Label ID="Label19" runat="server"></asp:Label>
                                    </td>
                                    <td class="auto-style5">
                                        <asp:Label ID="Label20" runat="server"></asp:Label>
                                    </td>
                                </tr><!--End of 10th Row-->
                            </table>
                        </asp:WizardStep>
                    </WizardSteps>
                </asp:Wizard>   
            </div><!--End startWizard-->

        </div><!--End wizard row-->
    </div><!--end container-->
</asp:Content>
