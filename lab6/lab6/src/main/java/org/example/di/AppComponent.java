package org.example.di;

import dagger.Component;
import org.example.services.OrderService;

@Component(modules = AppModule.class)
public interface AppComponent {
    OrderService getOrderService();
}
