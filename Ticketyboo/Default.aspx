<%@ Page Title="OCP - Homepage" Language="C#" MasterPageFile="MasterPages/Bootstrap.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OCP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ********************************** -->
    <!-- Main Content Area -->
    <!-- ********************************** -->

    <div id="main" role="main" class="mainArea">
        <div class="container-fluid">
            <div>
                <div class="row">
                    <h1>Welcome to Operational Checklist Portal</h1>
                    <p>Online checklists to help you plan and manage your daily workload. </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterPlaceHolder" runat="server">
    <div class="footer">
        <p>&copy; <%: DateTime.Now.Year %> - DST</p>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
    
</asp:Content>
