CREATE TABLE IF NOT EXISTS profiles(
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    name varchar(255) COMMENT 'User Name',
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS accounts(
    id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
    name varchar(255) COMMENT 'User Name',
    email VARCHAR(255) NOT NULL,
    picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE IF NOT EXISTS follows(
    id INT AUTO_INCREMENT NOT NULL primary key,
    followingId VARCHAR(255) NOT NULL,
    followerId VARCHAR(255) NOT NULL,
    FOREIGN KEY (followingId) REFERENCES profiles(id) ON DELETE CASCADE,
    FOREIGN KEY (followerId) REFERENCES profiles(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';