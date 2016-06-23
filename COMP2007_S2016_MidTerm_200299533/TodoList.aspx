<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200299533.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo List</h1>
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add Todo</a>

               

                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="TodosGridView" AutoGenerateColumns="false" DataKeyNames="TodoID"
                    OnRowDeleting="TodosGridView_RowDeleting" AllowPaging="true" PageSize="3"
                    OnPageIndexChanging="TodosGridView_PageIndexChanging" AllowSorting="true"
                    OnSorting="TodosGridView_Sorting" OnRowDataBound="TodosGridView_RowDataBound" 
                    PagerStyle-CssClass="pagination-ys">
                    <Columns>
                        <asp:BoundField DataField="TodoID" HeaderText="Todo ID" Visible="true" SortExpression="TodoID" />
                        <asp:BoundField DataField="Name" HeaderText="Todo Name" Visible="true" SortExpression="TodoName" />
                        <asp:BoundField DataField="Notes" HeaderText="Todo Notes" Visible="true" SortExpression="Todo Notes" />
                        
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
