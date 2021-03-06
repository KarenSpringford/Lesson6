﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Lesson6.Navbar" %>
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
            <a class="navbar-brand" href="/Default.aspx"><i class="fa fa-graduation-cap" aria-hidden="true"></i> Contoso University</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li id="home" runat="server"><a href="/Default.aspx"><i class="fa fa-home fa-lg" aria-hidden="true"></i>  Home</a></li>
                
                <!--added to ensure that the following links are only avail when logged in-->
                <asp:PlaceHolder ID="PublicPlaceholder" runat="server" >
                <!--- added the login -->
                <li id="login" runat="server"><a href="/Login.aspx"><i class="fa fa-sign-in fa-lg" aria-hidden="true"></i>  Login</a></li>
                <!--- added the register -->
                <li id="register" runat="server"><a href="/Register.aspx"><i class="fa fa-user-plus fa-lg" aria-hidden="true"></i>  Register</a></li>
                </asp:PlaceHolder>
                
                <!---Contoso placeholder-->
                <asp:PlaceHolder ID="ContosoPlaceholder" runat="server">
                <!--- added the main menu -->
                <li id="mainmenu" runat="server"><a href="/Contoso/MainMenu.aspx"><i class="fa fa-newspaper-o" aria-hidden="true"></i>  Main Menu</a></li>
                <li id="students" runat="server"><a href="/Contoso/Students.aspx"><i class="fa fa-leanpub" aria-hidden="true"></i>  Students</a></li>
                <li id="courses" runat="server"><a href="/Contoso/Courses.aspx"><i class="fa fa-book fa-lg" aria-hidden="true"></i>  Courses</a></li>
                <li id="departments" runat="server"><a href="/Contoso/Departments.aspx"><i class="fa fa-puzzle-piece fa-lg" aria-hidden="true"></i>  Departments</a></li>
                <!--- logout -->
                <li id="logout" runat="server"><a href="/Logout.aspx"><i class="fa fa-sign-out fa-lg" aria-hidden="true"></i>  Logout</a></li>
                </asp:PlaceHolder>

                <li id="contact" runat="server"><a href="/Contoso/Contact.aspx"><i class="fa fa-phone fa-lg" aria-hidden="true"></i>  Contact</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
