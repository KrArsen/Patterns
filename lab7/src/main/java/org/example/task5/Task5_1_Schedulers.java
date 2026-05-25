package org.example.task5;

import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;

public class Task5_1_Schedulers {

    public static void run() throws InterruptedException {
        Observable.just("photo_1.jpg", "photo_2.jpg", "photo_3.jpg")
            .subscribeOn(Schedulers.io())
            .map(photo -> {
                System.out.println("[" + Thread.currentThread().getName()
                    + "] [ЗАВАНТ] Завантаження: " + photo);
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                }
                return photo;
            })
            .observeOn(Schedulers.computation())
            .map(photo -> {
                System.out.println("[" + Thread.currentThread().getName()
                    + "] [СТИСК] Стиснення: " + photo);
                try {
                    Thread.sleep(500);
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                }
                return photo;
            })
            .observeOn(Schedulers.trampoline())
            .subscribe(photo -> System.out.println("[" + Thread.currentThread().getName()
                + "] [ФОТО] Відображення: " + photo));

        Thread.sleep(10_000);
    }
}
