package org.example.services;

import javax.inject.Inject;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;

public class LoggerService {

    @Inject
    public LoggerService() {}

    public void log(String message) {
        String time = LocalTime.now().format(DateTimeFormatter.ofPattern("HH:mm:ss"));
        System.out.println("[LOG " + time + "] " + message);
    }
}
