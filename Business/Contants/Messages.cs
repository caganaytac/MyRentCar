using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contants
{
    public static class Messages
    {
        public static string CarAdded = "Car added successfully!";
        public static string CarUpdated = "Car updated successfully!";
        public static string CarDeleted = "Car deleted successfully!";
        public static string CarNameInvalid = "Car name is invalid!";
        public static string CarsListed = "Cars listed!";
        public static string CarNameAlreadyExists = "The car cannot added because the car name already exists.";

        public static string MaintenanceTime = "Maintenance Time!";


        public static string BrandAdded = "Brand added successfully!";
        public static string BrandUpdated = "Brand updated successfully!";
        public static string BrandDeleted = "Brand deleted successfully!";
        public static string BrandCountLimitExceeded = "The limit on the number of brands has been exceeded, so no brands can be added.";
        public static string BrandNameAlreadyExists = "The brand cannot added because the brand name already exists.";

        public static string ColorAdded = "Color added successfully!";
        public static string ColorUpdated = "Color updated successfully!";
        public static string ColorDeleted = "Color deleted successfully!";
        public static string ColorCountLimitExceeded = "The limit on the number of colors has been exceeded, so no colors can be added.";
        public static string ColorNameAlreadyExists = "The color cannot added because the color name already exists.";

        public static string CustomerAdded = "Customer added successfully!";
        public static string CustomerUpdated = "Customer updated successfully!";
        public static string CustomerDeleted = "Customer updated successfully!";
        public static string CustomerIsNotUser = "Customer must be a user.";
        public static string CarIsNotExists = "Car is not exists.";

        public static string IncorrectFileExtensions = "Unacceptable file extension.";
        public static string CarImageAdded = "Car image added successfully!";
        public static string CarImageDeleted = "Car image updated successfully!";
        public static string CarImageUpdated = "Car image deleted successfully!";
        public static string CarImageLimitExceeded = "Car Image count can't be more than 5.";

        public static string UserNotFound = " User not found.";
        public static string PasswordError = "Password is incorrect.";
        public static string SuccessfulLogin = "Login was successfully.";
        public static string UserAlreadyExists = "User is already exists.";
        public static string UserRegistered = "User registered successfully.";
        public static string AccessTokenCreated = "Access token generated successfully.";

        public static string AuthorizationDenied = " You have not auth.";
        public static string ProductNameAlreadyExists = "Product name is already exists";
        public static string ProductCountErrorOfCategoryError = "You have exceeded the product limit in the relevant category.";
        public static string CategoryLimitExceded = "Product couldn't add. Because category limit exceeded.";

        public static string CarCanNotBeRented = "Car can't be rented.";
        public static string RentalAdded = "Rental added successfully.";
        public static string RentalUpdated = "Rental updated successfully.";
        public static string RentalDeleted = "Rental deleted successfully.";
        public static string RentalIsNotExist = "Rental is not exist.";
        public static string CarNotAvaible ="Car not avaible for rent.";
        public static string PaymentCompleted = "Payment completed.";
        public static string InsufficientBalance = "Insufficient balance.";
    }
}
