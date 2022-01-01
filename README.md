# Разработка | WPF | C#

### Git Terminal Commands

+ Иницилизируем  `.git` файл
```
git init
```
+ Регистрируем изменения
```
git add .
```
точка индексирует все файлы в проекте

+ Можем регистрировать изменения в конкретном файле
```
git add "name_file"
```

+ Комментируем изменения
```
git commit -m "Ваш комментарий"
```

+ Устанавливаем ссылку на уделённый репозиторий
```
git remote add origin "ссылка на ваш репозиторий.git"
```

+ Зафиксировать изменения в удалённом репозитории
```
git push -u origin master
```
#

+ Создать ветку и переключиться на неё
```git
git checkout -b name_branch
```
+ Узнать текущюю ветку
```git
git branch
```
+ Переключаться между ветками
```
git checkout name_branch
```
+ Создать Annotated Tags | Пример
```git
git tag -a v1.4 -m "my version 1.4"
```
+ Сохранить Tag
```git
git push -u v1.4
```
+ При ошибке 
`Please make sure you have the correct access rights
and the repository exists.`

Используйте команду 
```
git remote set-url origin https://github.com/username/repository.git
```
