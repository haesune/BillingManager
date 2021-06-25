namespace ConsoleApplication5.BillingInterface
{
    class Item
    {
   
        public int itemId;
        public string itemName;
        public double itemPrice;

        public Item(int itemId, string itemName, double itemPrice) {
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemPrice = itemPrice;
        }
    }

}


