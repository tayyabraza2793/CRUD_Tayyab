<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CRUD_Tayyab.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LoginView ID="login" runat="server"></asp:LoginView>
            <asp:Label ID="lbl_name" runat="server" Text="Enter the name" ></asp:Label><br />
            <asp:TextBox ID="txt_name" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbl_pass" runat="server" Text="Enter the pass" ></asp:Label><br />
            <asp:TextBox ID="txt_pass" runat="server"></asp:TextBox><br />
            <asp:Label ID="lbl_age" runat="server" Text="Enter the Age" ></asp:Label><br />
            <asp:DropDownList ID ="ddl_age" runat="server" ></asp:DropDownList><br />
            <asp:Label ID="lbl_gender" runat="server" Text="Select the gender" ></asp:Label><br />
            <asp:RadioButton ID="rad_male" runat="server" Text="Male" />
            <asp:RadioButton ID="rad_female" runat="server" Text="Female" /><br />
            <asp:Label ID="lbl_course" runat="server" Text="Select the course"></asp:Label><br />
            <asp:DropDownList ID="ddl_course" runat="server" OnSelectedIndexChanged="ddl_course_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList><br />
            <asp:Button ID="btn_submit" runat="server" Text="Save Record" OnClick="btn_submit_Click" />
            <asp:Button ID="btn_del" runat="server" Text="Delete Record" OnClick="btn_del_Click" />
            <asp:Button ID="btn_upd" runat="server" Text="Update Record" OnClick="btn_upd_Click" /><br />
            <asp:Label ID="lbl_id" runat="server" Text="ID"></asp:Label><br />
            <asp:DropDownList ID="ddl_id" runat="server" DataSourceID="SqlDataSource1" DataTextField="S_ID" DataValueField="S_ID"  AutoPostBack="true" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayyabDbConnectionString2 %>" SelectCommand="SELECT [S_ID] FROM [students]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lbl_exception" runat="server" ></asp:Label><br />

            <h1>Delete Records</h1>
            <asp:DropDownList ID="ddl_del_id" runat="server" DataSourceID="SqlDataSource1" DataTextField="S_ID" DataValueField="S_ID"  AutoPostBack="true" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TayyabDbConnectionString2 %>" SelectCommand="SELECT [S_ID] FROM [students]"></asp:SqlDataSource>
            <br />
            <asp:Label ID="lbl_del" runat="server" Text="delete ID"></asp:Label><br />
      
            

        </div>
    </form>
</body>
</html>
