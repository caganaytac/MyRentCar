namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfully!";
        public static string CarUpdated = "Car updated successfully!";
        public static string CarDeleted = "Car deleted successfully!";
        public static string DailyPriceCanNot0 = "Daily Price must greater than 0.";
        public static string MinCarName = "Car name contains 2-10 characters.";
        public static string CarsListed = "Cars listed!";

        public static string BrandAdded = "Brand added successfully!";
        public static string BrandUpdated = "Brand updated successfully!";
        public static string BrandDeleted = "Brand deleted successfully!";
        public static string BrandCountLimitExceeded = "The limit on the number of brands has been exceeded, so no brands can be added.";
        public static string BrandNameAlreadyExists = "The brand cannot added because the brand name already exists.";
        public static string BrandNameNotEmpty = "Brand name can't be empty.";
        public static string BrandLengthMin2 = "Brand name must contains minimum 2 characters.";

        public static string ColorAdded = "Color added successfully!";
        public static string ColorUpdated = "Color updated successfully!";
        public static string ColorDeleted = "Color deleted successfully!";
        public static string ColorNameAlreadyExists = "The color cannot added because the color name already exists.";
        public static string ColorNameNotEmpty = "Color name can't be empty.";
        public static string ColorLengthMin2 = "Color name must contains minimum 2 characters.";

        public static string CustomerAdded = "Customer added successfully!";
        public static string CustomerUpdated = "Customer updated successfully!";
        public static string CustomerDeleted = "Customer updated successfully!";
        public static string CustomerIsNotUser = "Customer must be a user.";

        public static string CarImageLimitExceeded = "Car Image count can't be more than 5.";

        public static string UserNotFound = " User not found.";
        public static string PasswordError = "Password is incorrect.";
        public static string SuccessfullLogin = "Logged in successfully.";
        public static string UserAlreadyExists = "User is already exists.";
        public static string UserRegistered = "User registered successfully.";
        public static string AccessTokenCreated = "Logged in successfully.";
        public static string PasswordChanged = "Password changed.";
        public static string UserClaimAdded ="User claim added.";


        public static string AuthorizationDenied = " You have not auth.";


        public static string RentalAdded = "Rental added successfully.";
        public static string RentalUpdated = "Rental updated successfully.";
        public static string RentalDeleted = "Rental deleted successfully.";
        public static string RentalIsNotExist = "Rental is not exist.";
        public static string CarNotAvailable ="Car not available for rent.";
        public static string PaymentCompleted = "Payment completed.";
        public static string PaymentFailed = "Payment failed. Please try again.";

        public static string EmailNotEmpty = "Email can't be empty.";
        public static string IsNotEmail = "Please enter an email.";
        public static string FirstNameNotEmpty = "First name can't be empty.";
        public static string FirstNameLength = "First name must contain 2-10 characters.";
        public static string LastNameNotEmpty = "Last name can't be empty.";
        public static string LastNameLength = "Last name must contain 2-10 characters.";
        public static string PasswordNotNull = "Password can't be empty.";
        public static string PasswordLength = "Password must contain 8-80 characters.";
        public static string CreditScoreInsufficient="Your credit score is insufficient for rent this car.";

        public static string CardHolderNameNotNull="Card Name can't be null.";
        public static string ExpMonthNotNull = "Expiration Month can't be null.";
        public static string ExpMonthInclusiveBetween = "Expiration Month must be a month (1-12).";
        public static string ExpYearhNotNull = "Expiration Year can't be null.";
        public static string ExpYearInclusiveBetween = "Expiration Year must be 2021 between 2050.";
        public static string CvcNotNull = "Cvc can't be null.";
        public static string CvcLength3 = "Cvc length is 3 number.";
        public static string CardNumberNotNull="Card Number can't be null.";
        public static string CardNumberLength16 = "Please enter an existing card number.";
        public static string UserProfilePhotoDeleted = "Your profile photo removed.";
        public static string UserProfilePhotoUpdated = "Your profile photo updated.";
        public static string UserProfilePhotoAdded = "Your profile photo added.";

    }
}
