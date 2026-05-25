package org.example.di;

import dagger.Module;
import dagger.Provides;
import org.example.services.*;

@Module
public class AppModule {

    @Provides
    LoggerService provideLoggerService() {
        return new LoggerService();
    }

    @Provides
    ProductRepository provideProductRepository() {
        return new ProductRepository();
    }

    @Provides
    UserRepository provideUserRepository() {
        return new UserRepository();
    }

    @Provides
    PaymentService providePaymentService(ProductRepository productRepository,
                                         LoggerService loggerService) {
        return new PaymentService(productRepository, loggerService);
    }

    @Provides
    NotificationService provideNotificationService(LoggerService loggerService) {
        return new NotificationService(loggerService);
    }

    @Provides
    OrderService provideOrderService(PaymentService paymentService,
                                     NotificationService notificationService,
                                     UserRepository userRepository) {
        return new OrderService(paymentService, notificationService, userRepository);
    }
}
