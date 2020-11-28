Imports System.Data
Partial Class _Default
    Inherits System.Web.UI.Page
    Public Shared gdtRentals, individual, vehicleType, grandTotal As New DataTable

    'Data table initialization
    Private Sub Rentals(sender As Object, e As EventArgs) Handles Me.Init


        If individual.Columns.Count > 0 Then Exit Sub
        If vehicleType.Columns.Count > 0 Then Exit Sub
        If grandTotal.Columns.Count > 0 Then Exit Sub



        'invoice ledger initialization
        With gdtRentals.Columns
            .Add("Invoice ID", GetType(Integer))
            .Add("Checkout Date", GetType(String))
            .Add("Checkin Date", GetType(String))
            .Add("Checkout Mileage", GetType(Integer))
            .Add("Checkin Mileage", GetType(Integer))
            .Add("Vehicle Type", GetType(String))
            .Add("Total Charges", GetType(Integer))
            .Add("Reservation Total Count", GetType(Integer))
        End With

        'auto incrementing for each invoice id
        With gdtRentals.Columns("Invoice ID")
            .AutoIncrement = True
            .AutoIncrementSeed = 10000
            .AutoIncrementStep = 1
        End With

        'set running total for reservations
        gdtRentals.Columns("Reservation Total Count").DefaultValue = 0



        'individual vehicle data table initialization
        With individual.Columns
            .Add("Vehicle ID", GetType(String))
            .Add("Current Mileage", GetType(Integer))
            .Add("Needs Maintainence", GetType(Boolean))
        End With

        For Each li As ListItem In DropDownList1.Items
            Dim dr2 As DataRow = individual.NewRow
            dr2.Item("Vehicle ID") = li.Text
            individual.Rows.Add(dr2)
        Next

        GridView2.DataSource = individual
        GridView2.DataBind()



        'vehicle type initialization
        With vehicleType
            .Columns.Add("Vehicle Type", GetType(String))
            .Columns.Add("Total Mileage", GetType(Integer))

            .Columns("Total Mileage").DefaultValue = 0
        End With

        Dim dr3 As DataRow = vehicleType.NewRow
        Dim dr4 As DataRow = vehicleType.NewRow
        Dim dr5 As DataRow = vehicleType.NewRow
        dr3.Item("Vehicle Type") = "Sedan"
        vehicleType.Rows.Add(dr3)
        dr4.Item("Vehicle Type") = "Van"
        vehicleType.Rows.Add(dr4)
        dr5.Item("Vehicle Type") = "Pickup"
        vehicleType.Rows.Add(dr5)

        GridView4.DataSource = vehicleType
        GridView4.DataBind()


        'grand total initialization
        With grandTotal
            .Columns.Add("Total Times Rented", GetType(Integer))
            .Columns.Add("Total Days Rented", GetType(Integer))
            .Columns.Add("Total Miles Traveled", GetType(Integer))
            .Columns.Add("Total Revenue Generated", GetType(Decimal))

            .Columns("Total Times Rented").DefaultValue = 0
            .Columns("Total Days Rented").DefaultValue = 0
            .Columns("Total Miles Traveled").DefaultValue = 0
            .Columns("Total Revenue Generated").DefaultValue = 0
        End With

        Dim dr As DataRow = grandTotal.NewRow
        grandTotal.Rows.Add(dr)

        GridView3.DataSource = grandTotal
        GridView3.DataBind()

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'input error checking
        If TextBox1.Text = Nothing OrElse TextBox2.Text = Nothing Then
            TextBox3.Text = "Check entries for time and date."
            Exit Sub
        End If

        If TextBox4.Text = Nothing OrElse TextBox5.Text = Nothing Then
            TextBox3.Text = "Check entries for mileage."
            Exit Sub
        End If

        If DropDownList1.SelectedIndex = -1 Then
            TextBox3.Text = "Please select a vehicle type."
            Exit Sub
        End If


        'We are going to be using TextMode for textbox 4,5 that inputs as text in the form "MM/DD/YYYY"
        'because of a non funtioning "date" textbox functionality. It will then be converted to a date to then be processed
        Dim begDate = Convert.ToDateTime(TextBox1.Text)
        Dim endDate = Convert.ToDateTime(TextBox2.Text)
        Dim ts As TimeSpan = endDate - begDate

        'check if date is invalid
        If ts.TotalDays < 0 Then
            TextBox3.Text = "Please check date entries."
            Exit Sub
        End If

        If begDate.Date > Today.Date OrElse endDate.Date > Today.Date Then
            TextBox3.Text = "Please check date entries."
            Exit Sub
        End If

        'Integer data variables
        Dim totalMileage As Integer = 0
        Dim additionalCharges As Integer = 0
        Dim mileageCost As Integer = 0
        Dim totalCost As Integer = 0
        Dim pricePerDay As Integer = 0

        'sedan 0,1,2 van 3,4,5 pickup 6,7
        If (DropDownList1.SelectedIndex = 0 Or 1 Or 2) Then
            pricePerDay = 30
        End If
        If (DropDownList1.SelectedIndex = 3 Or 4 Or 5) Then
            pricePerDay = 70
        End If
        If (DropDownList1.SelectedIndex = 6 Or 7) Then
            pricePerDay = 90
        End If

        'calculate mileage charge
        totalMileage = TextBox5.Text - TextBox4.Text
        mileageCost = (0.25 * totalMileage)

        'calculate extra charges
        Dim item As ListItem
        For Each item In CheckBoxList1.Items
            If item.Selected = True Then
                additionalCharges += item.Value
            End If
        Next

        'calculate total cost
        totalCost = mileageCost + additionalCharges + (ts.TotalDays * pricePerDay)

        'display to textbox the subtotal and total cost for the invoice
        TextBox3.Text = "Daily cost of vehicle for " & ts.TotalDays.ToString & " days is: $" &
            pricePerDay * ts.TotalDays & vbNewLine &
            "Mileage charges: $" & mileageCost & vbNewLine &
            "Additional charges: $" & additionalCharges & vbNewLine &
            "Total cost: $" & totalCost


        'invoice ledger data table
        Dim dr As DataRow = gdtRentals.NewRow

        dr.Item("Checkout Date") = begDate.ToShortDateString
        dr.Item("Checkin Date") = endDate.ToShortDateString
        dr.Item("Checkout Mileage") = TextBox4.Text
        dr.Item("Checkin Mileage") = TextBox5.Text
        dr.Item("Vehicle Type") = DropDownList1.SelectedValue
        dr.Item("Total Charges") = totalCost
        dr.Item("Reservation Total Count") += 1

        gdtRentals.Rows.Add(dr)
        GridView1.DataSource = gdtRentals
        GridView1.DataBind()



        'individual vehicle data table
        With individual.Rows(DropDownList1.SelectedIndex)
            .Item("Current Mileage") = TextBox5.Text

            If (TextBox5.Text > 10000) Then
                .Item("Needs Maintainence") = True
            End If
        End With
        'set data table to the gridview
        GridView2.DataSource = individual
        GridView2.DataBind()



        ' grand total table
        With grandTotal.Rows(0)
            .Item("Total Times Rented") += 1
            .Item("Total Days Rented") += ts.TotalDays
            .Item("Total Miles Traveled") += totalMileage
            .Item("Total Revenue Generated") += totalCost
        End With
        ' set to gridview
        GridView3.DataSource = grandTotal
        GridView3.DataBind()



        'vehicle type table
        ' val is used to index between each vehicle type in drop down list1
        Dim val As Integer
        If (DropDownList1.SelectedValue = "Sedan1" Or DropDownList1.SelectedValue = "Sedan2" Or DropDownList1.SelectedValue = "Sedan3") Then
            val = 0
        ElseIf (DropDownList1.SelectedValue = "Van1" Or DropDownList1.SelectedValue = "Van2") Then
            val = 1
        ElseIf (DropDownList1.SelectedValue = "Pickup1" Or DropDownList1.SelectedValue = "Pickup2") Then
            val = 2
        End If

        With vehicleType.Rows(val)
            .Item("Total Mileage") += totalMileage
        End With
        'set to gridview
        GridView4.DataSource = vehicleType
        GridView4.DataBind()

    End Sub
End Class
