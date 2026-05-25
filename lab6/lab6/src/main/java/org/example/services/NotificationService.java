package org.example.services;

import javax.inject.Inject;

public class NotificationService {

    private final LoggerService loggerService;

    @Inject
    public NotificationService(LoggerService loggerService) {
        this.loggerService = loggerService;
    }

    public void sendConfirmation(int userId, String message) {
        loggerService.log("Надсилання повідомлення користувачу " + userId);
        System.out.println("[EMAIL] Повідомлення надіслано: " + message);
    }
}
