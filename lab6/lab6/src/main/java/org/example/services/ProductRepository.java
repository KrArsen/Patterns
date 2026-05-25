package org.example.services;

import javax.inject.Inject;

public class ProductRepository {

    @Inject
    public ProductRepository() {}

    public String getProductName(int productId) {
        return switch (productId) {
            case 1 -> "Laptop";
            case 2 -> "Phone";
            default -> "Unknown";
        };
    }

    public double getProductPrice(int productId) {
        return switch (productId) {
            case 1 -> 1200.00;
            case 2 -> 800.00;
            default -> 0.0;
        };
    }
}
