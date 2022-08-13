namespace ClientManagmentSystem;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // # Menu #

        // List all active clients
            //show:
            //Client Id
            //Name
            //Vat number
            //Availble credit
        
        // List all active client, with positive availble credit
            //show:
            //Client Id
            //Name
            //Availble credit value
            //Credit validity
        
        // List all active clients with expired credit validity 
            //show:
            //Client Id
            //Name
            //Availble credit value
            //For how long the credit has expired
        // List a single client
            //show:
            //Client ID -> array index +1
            //Name
            //Address
            //Postal code
            //Locality
            //Phone number
            //Email
            //VAT number
            //Current credit
            //Credit validity
        // Add a new client
        // Remove a client (make inactive)
        // Edit a client
        // List a clients balance sheet
            //show:
            //Client Id
            //Name
            //DateTime for operation
            //Amount (+ for charging the trip pass, - for trip made, thus amount debited from trip pass)
        // Add a trip to a client
            //show:
            //Client ID (?)
            //Client Name (?) 
            //Trip cost
            //DateTime of the charge for the trip
        // Add credit to trip pass
            //Client ID (?)
            //Client Name (?) 
            //Amount paid by the client
            //DateTime of the payment
    }
}
