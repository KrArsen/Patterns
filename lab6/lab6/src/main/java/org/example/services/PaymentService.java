package org.example.services;

import javax.inject.Inject;

public class PaymentService {

    private final ProductRepository productRepository;
    private final LoggerService loggerService;

    @Inject
    public PaymentService(ProductRepository productRepository,
                          LoggerService loggerService) {
        this.productRepository = productRepository;
        this.loggerService = loggerService;
    }

    public boolean processPayment(int userId, int productId, int quantity) {
        String productName = productRepository.getProductName(productId);
        double price = productRepository.getProductPrice(productId) * quantity;

        loggerService.log("Обробка оплати " + price + "$ за " + quantity
                + "x " + productName + " для користувача " + userId);

        System.out.println("[PAYMENT] Оплата " + price + "$ успішно оброблена");
        return true;
    }
}
