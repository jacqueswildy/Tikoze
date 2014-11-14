<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tikoze._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="container">
        <hgroup>
            <h1></h1>
        </hgroup>
        <div class="form-group form-group-lg form-horizontal">
            <label class="col-sm-2 control-label sr-only" for="formGroupInputLarge">Search</label>
            <div class="row">
                <div class="col-sm-10">
                    <input class="form-control" type="search" id="formGroupInputLarge" placeholder="Search for lyrics, artists, song titles or albums">
                    <div>
                        <label class="radio-inline">
                          <input type="radio" name="inlineRadioOptions" id="inlineRadio1" value="option1"> lyrics
                        </label>
                        <label class="radio-inline">
                          <input type="radio" name="inlineRadioOptions" id="inlineRadio2" value="option2"> artists
                        </label>
                        <label class="radio-inline">
                          <input type="radio" name="inlineRadioOptions" id="inlineRadio3" value="option3"> song titles
                        </label>
                        <label class="radio-inline">
                          <input type="radio" name="inlineRadioOptions" id="inlineRadio4" value="option4"> albums
                        </label>
                    </div>
                </div>
                <div class="col-sm-2">
                    <button type="submit" class="btn btn-default">Search</button>
                </div>
            </div>
        </div>
    </div><!--end container-->

    <div class="container">
        <div class="jumbotron center-block">
            <hgroup>
                <h1>Contribute</h1>
            </hgroup>
            <p class="bg-default lead">This project is relying on YOU to grow. Add a song or an album. It will take less than 5 minutes!</p>
            <button type="button" class="btn btn-success btn-lg center-block">Add a song &raquo;</button>
        </div>
    </div><!--end container-->

    <div class="container">
        <div class="row">
            <div class="col-md-4">
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
            </div><!--end column-->

            <div class="col-md-4">
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
            </div><!--end column-->

            <div class="col-md-4">
                <hgroup>
                    <h3>5 Most Recent Songs</h3>
                </hgroup>
                <ol>
                    <li>Song Title number 1</li>
                    <li>Second Song Title</li>
                    <li>Song Title numero 3</li>
                    <li>This is Song Title number 4</li>
                    <li>View Song Title #5 </li>
                </ol>
            </div><!--end column-->
        </div>
    </div><!--end container-->
    
    
</asp:Content>