`SELECT rating,COUNT(*) from film GROUP BY rating`

`SELECT replacement_cost,COUNT(*) from film GROUP BY replacement_cost HAVING COUNT(*)>50`

`SELECT store_id,COUNT(*) from customer GROUP BY store_id`

`SELECT country_id,COUNT(*) as city_number from city GROUP BY country_id ORDER BY count(*) DESC LIMIT 1`

 
