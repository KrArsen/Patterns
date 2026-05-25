package org.example.services;

import javax.inject.Inject;

public class OrderService {

    private final PaymentService paymentService;
    private final NotificationService notificationService;
    private final UserRepository userRepository;

    @Inject
    public OrderService(PaymentService paymentService,
                        NotificationService notificationService,
                        UserRepository userRepository) {
        this.paymentService = paymentService;
        this.notificationService = notificationService;
        this.userRepository = userRepository;
    }

    public void placeOrder(int userId, int productId, int quantity) {
        System.out.println("\n=== Створення замовлення ===");

        String userName = userRepository.getUserName(userId);
        String userEmail = userRepository.getUserEmail(userId);
        System.out.println("Користувач: " + userName + " (" + userEmail + ")");

        boolean paid = paymentService.processPayment(userId, productId, quantity);

        if (paid) {
            notificationService.sendConfirmation(userId,
                    "Замовлення #" + productId + " на " + quantity
                    + " шт. підтверджено!");
        }

        System.out.println("=== Замовлення завершено ===\n");
    }
}
