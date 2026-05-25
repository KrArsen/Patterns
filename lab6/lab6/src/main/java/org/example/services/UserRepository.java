package org.example.services;

import javax.inject.Inject;

public class UserRepository {

    @Inject
    public UserRepository() {}

    public String getUserEmail(int userId) {
        return userId == 1 ? "user@example.com" : "guest@example.com";
    }

    public String getUserName(int userId) {
        return userId == 1 ? "John Doe" : "Guest";
    }
}
