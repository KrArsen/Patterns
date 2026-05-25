package org.example.task4;

import io.reactivex.rxjava3.core.Completable;
import io.reactivex.rxjava3.core.Maybe;
import io.reactivex.rxjava3.core.Single;

public class Task4_2_MaybeCompletable {

    // Частина A — Maybe
    public static Maybe<String> findInCache(String key) {
        return switch (key) {
            case "user:1"     -> Maybe.just("{'name':'Леся','age':28}");
            case "user:2"     -> Maybe.empty();
            case "user:error" -> Maybe.error(new RuntimeException("Redis недоступний"));
            default           -> Maybe.empty();
        };
    }

    // Частина B — Completable ланцюжок
    public static Completable validateInput() {
        return Completable.fromAction(() -> {
            System.out.println("[ПОШУК] Перевірка даних...");
            System.out.println("(+) Дані валідні");
        });
    }

    public static Completable saveToDatabase(boolean shouldFail) {
        return Completable.fromAction(() -> {
            System.out.println("[DB] Збереження в БД...");
            if (shouldFail)
                throw new RuntimeException("DB недоступна");
            System.out.println("(+) Збережено");
        });
    }

    public static Single<String> generateToken() {
        return Single.fromCallable(() -> {
            System.out.println("[ТОКЕН] Генерація токена...");
            return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.demo";
        });
    }

    public static void run() {
        System.out.println("=== Maybe ===");

        findInCache("user:1")
            .defaultIfEmpty("Завантажено з БД")
            .subscribe(
                v -> System.out.println("[КЕШ (+)] Знайдено: " + v),
                e -> System.out.println("[КЕШ (!)] Помилка: " + e.getMessage())
            );

        findInCache("user:2")
            .defaultIfEmpty("Завантажено з БД")
            .subscribe(
                v -> System.out.println("[КЕШ (-)] Кеш-міс. Значення: " + v),
                e -> System.out.println("[КЕШ (!)] Помилка: " + e.getMessage())
            );

        findInCache("user:error")
            .defaultIfEmpty("Завантажено з БД")
            .subscribe(
                v -> System.out.println("[КЕШ (+)] Знайдено: " + v),
                e -> System.out.println("[КЕШ (!)] Помилка: " + e.getMessage())
            );

        System.out.println("\n=== Completable — успіх ===");
        validateInput()
            .andThen(saveToDatabase(false))
            .andThen(generateToken())
            .subscribe(
                token -> System.out.println("[ТОКЕН] Токен: " + token
                    + "\n(+) Реєстрацію завершено успішно!"),
                error -> System.out.println("(-) Помилка: " + error.getMessage())
            );

        System.out.println("\n=== Completable — помилка в saveToDatabase ===");
        validateInput()
            .andThen(saveToDatabase(true))
            .andThen(generateToken())
            .subscribe(
                token -> System.out.println("(+) Токен: " + token),
                error -> System.out.println("(-) Помилка: " + error.getMessage())
            );
    }
}
