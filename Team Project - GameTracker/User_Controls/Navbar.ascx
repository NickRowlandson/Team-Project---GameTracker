<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Team_Project___GameTracker.Navbar" %>
<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-gamepad fa-lg"></i> GAME TRACK</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">

                <li id="home" runat="server"><a href="/Default.aspx"><i class="fa fa-home fa-lg"></i> Home</a></li>
                <li id="contact" runat="server"><a href="/Contact.aspx"><i class="fa fa-phone fa-lg"></i> Contact</a></li>

                <asp:PlaceHolder ID="PublicPlaceHolder" runat="server">
                    <li id="login" runat="server"><a href="/Login.aspx"><i class="fa fa-sign-in fa-lg"></i> Login</a></li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="PrivatePlaceHolder" runat="server">
                    <li id="manageGames" runat="server"><a href="/GameTrack/ManageGames.aspx"><i class="fa fa-grid fa-lg"></i> Manage Games</a></li>
                    <li id="logout" runat="server"><a href="/Logout.aspx"><i class="fa fa-sign-out fa-lg"></i> Logout</a></li>
                </asp:PlaceHolder>

            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
