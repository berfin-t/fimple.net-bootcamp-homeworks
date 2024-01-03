`select city,country.country from city
JOIN country ON country.country_id=city.country_id`

`select first_name,last_name,payment.payment_id from customer
JOIN payment ON customer.customer_id=payment.customer_id`

`select first_name,last_name,rental.rental_id from customer
JOIN rental ON customer.customer_id=rental.rental_id`
