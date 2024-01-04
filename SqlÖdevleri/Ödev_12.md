```
SELECT COUNT(*) FROM film WHERE length>
(
SELECT AVG(length) from film)
)
```


```
SELECT COUNT(*) FROM film WHERE rental_rate=
(
SELECT MAX(rental_rate) from film
)

```

 ```
SELECT * FROM film WHERE rental_rate=
(
SELECT MIN(rental_rate) from film
)
AND replacement_cost=
(
SELECT MIN(replacement_cost) from film
)
```



```
SELECT customer.first_name,customer.last_name,COUNT(*) FROM payment 
JOIN customer ON customer.customer_id=payment.customer_id
GROUP BY customer.customer_id
ORDER BY count(*) DESC
```
