﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="_451AS03.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style type="text/css">
        html
        {
            background-color:silver;
        }
        .content
        {
            padding:10px;
            background-color:white;
        }
        .customers
        {
            margin-bottom:20px;
        }
        .customers td,.customers th
        {
            padding:5px;
            border-bottom:solid 1px blue;
        }
        a
        {
            color:blue;
        }
    </style>
    <title>Customers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
    
    <asp:GridView
        id="grdCustomers"
        DataSourceID="db"
        DataKeyNames="customer_id"
        AutoGenerateEditButton="true"
        AutoGenerateDeleteButton="true"
        AutoGenerateColumns="false"
        CssClass="customers" 
        GridLines="none"
        Runat="server">
        <Columns>
            <asp:BoundField
                DataField="Id"
                ReadOnly="true"
                HeaderText="Id" />
            <asp:BoundField
                DataField="Name"
                HeaderText="Name" />
            <asp:BoundField
                DataField="Address"
                HeaderText="Address" />
            <asp:BoundField
                DataField="Email"
                HeaderText="Email" />
        </Columns>
        </asp:GridView>

        <fieldset>
            <legend>Add Customer</legend>
            <asp:DetailsView
                id="dtlCustomer"
                DataSourceID="db"
                DefaultMode="Insert"
                AutoGenerateInsertButton="true"
                AutoGenerateRows="false"
                Runat="server">
                <Fields>
                    <asp:BoundField
                        DataField="Name"
                        HeaderText="Name:" />
                    <asp:BoundField
                        DataField="Address"
                        HeaderText="Address:" />
                    <asp:BoundField
                        DataField="Email"
                        HeaderText="Email:" />
                </Fields>
            </asp:DetailsView>
        </fieldset>

        <asp:ObjectDataSource
            id="db"
            TypeName="451AS03.BLL.Customer"
            SelectMethod="SelectAll"
            UpdateMethod="Update"
            InsertMethod="Insert"
            DeleteMethod="Delete"
            Runat="server" />

    </div>
    </form>
</body>
</html>