<%@ Page Title="OCP - TeamAdmin" Language="C#" MasterPageFile="~/MasterPages/Bootstrap.Master"
    AutoEventWireup="true" CodeBehind="TeamAdmin.aspx.cs"
    Inherits="OCP.Views.Admin.TeamAdmin"
    EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function AddData() {
            $("#hdnPK").val("-1");
            $("#lblTitle").text("Add New Team");
            $("#txtTeamName").val("");
            $("#btnSave").val("Create Team");
            $("#hdnAddMode").val("true");
            $('#teamDialog').modal();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ********************************** -->
    <!-- Main Content Area -->
    <!-- ********************************** -->

    <div id="main" role="main" class="mainArea">
        <div class="container-fluid">
            <div>
                <div class="row">
                    <h1>Team Admin</h1>
                    <p>Add / Delete OCP teams.</p>
                </div>
                <form id="frmTeams" runat="server">

                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-8">

                            <!-- Add Button -->
                            <a href="#" data-toggle="modal" onclick="AddData();" class="btn btn-success">Add New Team</a>
                            <button id="btnResetSort" type="submit" class="btn btn-primary" onserverclick="btnResetSort_Click" runat="server"><i class="fa fa-refresh"></i>Reset Sort Order</button>

                        </div>
                    </div>

                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-8">
                            <div class="modal fade" id="teamDialog" tabindex="-1" role="dialog">
                                <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal" aria-hidden="True">&times;</button>
                                            <h4 class="modal-title" id="lblTitle" runat="server">Team</h4>
                                        </div>
                                        <div class="modal-body">
                                            <input type="hidden" id="hdnPK" runat="server" />
                                            <input type="hidden" id="hdnAddMode" runat="server" value="false" />
                                            <div class="row">
                                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                    <div class="form-group">
                                                        <label for="txtTeamName">Team Name</label>
                                                        <div class="row">
                                                            <div class="col-xs-12 col-sm-8 col-md-8 col-lg-8">
                                                                <asp:TextBox ID="txtTeamName" runat="server" CssClass="form-control" autofocus="autofocus"
                                                                    required="required" placeholder="Team Name" title="Team Name"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="boolIsActive">IsActive</label>
                                                        <div class="row">
                                                            <div class="col-xs-12 col-sm-4 col-md-4 col-lg-4">
                                                                <asp:CheckBox ID="boolIsActive" runat="server" CssClass="form-control"
                                                                    placeholder="IsActive" title="IsActive" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="txtUpdatedBy"></label>
                                                        <div class="input-group">
                                                            <asp:TextBox ID="txtUpdatedBy" runat="server" CssClass="form-control"
                                                                placeholder="Updated By" title="Updated By"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div id="divMessageArea" runat="server" visible="false">
                                                        <div class="clearfix"></div>
                                                        <div class="row messageArea">
                                                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                                                <div class="well">
                                                                    <asp:Label ID="lblMessage" runat="server"
                                                                        CssClass="text-warning"
                                                                        Text="This is some text to show what a message would look like."></asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="btnCancel" runat="server"
                                                            Text="Cancel"
                                                            CssClass="btn btn-default"
                                                            title="Cancel"
                                                            data-dismiss="modal" />
                                                        <asp:Button ID="btnSave" runat="server"
                                                            Text="Create Team"
                                                            CssClass="btn btn-primary"
                                                            title="Create Team"
                                                            OnClick="btnSave_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grdAltTeams" runat="server"
                            CssClass="table table-striped table-bordered"
                            DataSourceID="odsTeam"
                            AllowPaging="True"
                            OnPageIndexChanging="grdAltTeams_OnPageIndexChanging"
                            PageSize="10"
                            AllowSorting="True"
                            OnSorting="grdAltTeams_OnSorting"
                            AutoGenerateColumns="False"
                            OnRowCommand="grdTeams_RowCommand"
                            EnableViewState="True">

                            <Columns>
                                <asp:TemplateField HeaderText="Team name" SortExpression="Name">
                                    <ItemTemplate>
                                        <a href="TeamAdmin.aspx?id=<%# Eval("Id") %>">
                                            <asp:Label ID="lblTeam" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />
                                <asp:BoundField DataField="UpdatedBy" HeaderText="UpdatedBy" SortExpression="UpdatedBy" />
                                <asp:BoundField DataField="UpdatedDate" HeaderText="UpdatedDate" SortExpression="UpdatedDate" />
                            </Columns>
                            <PagerStyle CssClass="pagination"></PagerStyle>
                            <PagerSettings Position="Bottom" Mode="NumericFirstLast"></PagerSettings>

                        </asp:GridView>
                        <p>
                            You are viewing page
        <%=grdAltTeams.PageIndex +1%>
        of
        <%=grdAltTeams.PageCount%>
                        </p>
                    </div>
                    <asp:ObjectDataSource ID="odsTeam" runat="server"
                        SortParameterName="SortExpression"
                        SelectMethod="GetTeams"
                        TypeName="OCP.Controllers.TeamController"></asp:ObjectDataSource>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="EndOfPageContent" runat="server">
</asp:Content>
