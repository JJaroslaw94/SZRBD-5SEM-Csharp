<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="SZRBD_web.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/css1.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="Centrowanie1">
            <div class ="StronaTabeli">
                <div class="Przyciski1">
                    <asp:Button ID="Button1" runat="server" Text="Dodaj Pracownika" OnClick="Button1_Click" />
                </div>
                <div class="Tabela1">
                    <br />
                    <asp:GridView ID="GridViewPrac" runat="server" AutoGenerateColumns="false" Width="590px">
                    <Columns>
                        <asp:BoundField DataField="ID_STANOWISKA" HeaderText="Stanowisko" />
                        <asp:BoundField DataField="ID_DZIALU" HeaderText="Dział" />
                        <asp:BoundField DataField="IMIE" HeaderText="Imię" />
                        <asp:BoundField DataField="NAZWISKO" HeaderText="Nazwisko" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranyPracownik2" Text="Select" runat="server" CommandArgument='<%# Eval("ID_PRACOWNIKA") %>' OnClick="WybranyPracownik2_Click" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybranyPracownik" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_PRACOWNIKA") %>' OnClick="WybranyPracownik_Click" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                </div>
            </div>

            <div class ="StronaTabeli">
                <div class="Przyciski1">
                    <asp:Button ID="Button2" runat="server" Text="Dodaj Zadanie" OnClick="Button2_Click" />
                    <asp:Button ID="Button3" runat="server" Text="Wszystkie" OnClick="Button3_Click" />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Wykonane?" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                </div>
                <div class="Tabela1">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="590px">
                    <Columns>
                        <asp:BoundField DataField="ID_PRACOWNIKA" HeaderText="Pracownik" />
                        <asp:BoundField DataField="NAZWA_ZADANIA" HeaderText="Zadanie" />
                        <asp:BoundField DataField="CZY_WYKONANE" HeaderText="Wykonane?" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="WybraneZadanie" Text="Edytuj" runat="server" CommandArgument='<%# Eval("ID_ZADANIA") %>' OnClick="WybraneZadanie_Click" /> 
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>                   
                </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
