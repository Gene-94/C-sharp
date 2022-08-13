Client managment system for urban passenger transportation company.

The client data, at this point, will be saved persitently through the use of cvs files
The type of that that will be store is of two types mainly, client info & client activity.

Interface will be console and data input will be done through it.




All client info is stored in a clients.csv file
    - one line per client
    - ';' separator for fields
    - ClientID;Active;Name;Address;PostalCode;City;Phone;Email;VAT;Credit;LastPayment




All operations are stored in a adicional file called balance.csv.

A client can charge his trip pass with payments, the minimum amount is 5€, the credit on the pass is never lost, but can only be used if a payment has been made within 30 days of last one.

Ex:
ClientID;operation DateTime;Amount
1;10/08/2022 22:33:55;-1.10
2;20/08/2022 15:14:13;10.00
2;21/08/2022 10:44:31;-1.50
2;22/08/2022 10:44:31;-2.50

    The negative amount refers to trip made, while the positive to a payment made to get credit on the trip pass.





The main goal of this project is to apply the knowledge acquired so far. 
