ALTER TABLE books  
ADD created_date datetime NOT NULL,
ADD modified_date datetime NOT NULL
AFTER title;

