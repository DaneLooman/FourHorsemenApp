﻿using FHM.Models;
using FHM.Models.FormatModels;
using FHM.Models.GameModel;
using FHM.Models.TournamentModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FHM.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            context.Database.EnsureCreated();

            if (userManager.FindByNameAsync("looman.dane@gmail.com").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "looman.dane@gmail.com";
                user.Email = "looman.dane@gmail.com";
                user.FirstName = "Dane";
                user.LastName = "Looman";
                user.Id = "User1";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Password1234!").Result;
            }

            if (!context.Games.Any())
            {
                var games = new Game[]
                {
                    new Game {GameName = "Magic The Gathering", GameShortDescription = "Classic Strategy Trading Card Game.", GameLongDescription = "Magic: The Gathering is both a trading card and digital collectible card game created by Richard Garfield. Released in 1993 by Wizards of the Coast, Magic was the first trading card game created and it continues to thrive, with approximately twenty million players as of 2015,and over twenty billion Magic cards produced in the period of 2008 to 2016 alone.Each game represents a battle between wizards known as planeswalkers, who employ spells, artifacts, and creatures depicted on individual Magic cards to defeat their opponents. Although the original concept of the game drew heavily from the motifs of traditional fantasy role-playing games such as Dungeons & Dragons, the gameplay of Magic bears little similarity to pencil-and-paper adventure games, while having substantially more cards and more complex rules than many other card games.", GameImageUrl = "https://227rsi2stdr53e3wto2skssd7xe-wpengine.netdna-ssl.com/wp-content/uploads/2017/01/mtg-banner-730x280.jpg", GameIsGameOfTheWeek = true, GameImageThumbnailURL = "data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxMQEhMTERETFRUVFRUYEhgWFxgWFhUVFhkWFxYXGBUYHSggGBwmGxcYIjMiJikrLi4uFx8zODMsNygtLisBCgoKDg0OGxAQGy0mICU3NS0tNy0uLS0tNzM3NTA3NS0vLS8tLS0tNS03NysyLSstLS8rKy8tLS0tLy0tLS0tLf/AABEIAOEA4QMBIgACEQEDEQH/xAAbAAEAAgMBAQAAAAAAAAAAAAAABQYBBAcDAv/EAEAQAAIBAwIDBQUFBgUDBQAAAAECAAMEERIhBQYxEyJBUWEHMnGBkRQjQoKhFlJicrHBFZKistEXJIMlM0NTVP/EABkBAQADAQEAAAAAAAAAAAAAAAADBAUCAf/EADERAAICAgAEBAMHBQEAAAAAAAABAgMEERIhMUEFE1FhgZHwFHGhscHR4SIjMnLxUv/aAAwDAQACEQMRAD8A7jERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERmAIiIAiIgCIjMARGZjMAzExmZgCIiAIiIAiIgCIzMZgGYjMQBExmZzAEREARMZmYAiMxAEwZmYaARHGuPUrRS1V1VR4k+PkPMyC/6jWf/wBw+h/4lY9rXC65q0qoRnoqNwoJ0tk6idIJGV2DeG8jeWbOxu9X3DIy4yO0qENnIyDq8xKmRkurtyNHHw6518cm/h2L0ntGsvGsPof+JaOGcRp3CCpRdXQ9CpyJzU8rWjKcU2BOQCKlTbwBPenh7M+MmyuKllX2FRy1Mnp2mAMfB1AI9QZxjZqufDrR7dhQUHKtva9Tql7cimpJlEb2o24croqsASNQUFTjbI3yR64ls5n4c9zbVqdNgrvTZVJ6AkYE4n9nNg3ZXtmCpOzYBOw/A494ADpscSe+yUFuK2R4dFdu1J8+y7nR29ptpjZ3z5dm+fpiSnK3OtvfsaaFlqDcI40lh4ld8H5dJUqHLloV1CkpBAIOWIwdxsTiRXDLamnGrVUU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c+N9jYvtjQty69l+pC8785NRUUKYzXKLnbIp6h1I8TnovjIXlrhZt6Zaow11MEgsBpUb97+Ikkn4yw888jVriuLmzZe07upWbTuuQrq2Dvg4wes1OE+y0uA99cMXPVEIIHxdwc/ICXcimy18PYrUW0VVb3zfX1/4KN9RyR2qfDWN/OQV3wytaVmueHVMjqyjDkL104/Gmc+o8Jba/sqtmHcr11ProYfQrImt7K6yH7i6T0yrIfqh/tIIYdlb4osmjlY8lpy+aNn/ABxOJ2FV6iaalJWV8MwGWXYqQQSpB6GSPN9BWSgHyP8AtagG7LvhNtiM7Dp6SQ5T5MS0t6lGq3aNVYNUK5UDTgKFOcjGBv5yWbl2i3v9o432eo7AZBBIBPXBO/rNKO9czIu4PMfB07ETdBKl5b0alCm4a0dizLlhpK7AnoN5B8Htg1qLlsVezr1ErKaXbOaSMyLSRfwHodXXzlw/ZujqDaq2oAgHtqmQD1Gcz6p8uUU/9vtEznUUqMpcnfLEHvH16zoiKwKnaWzEq60kroGR866dDUhdXz/CWPXoRPTjvC6j8QpvpqmlUQIHpEqaezau8oOBjzx70uNvY06admqgLvkdc56k565ml+z9LGkNVCfuCo4THlpzsPSAUq2sBTe+0jNK1IpopTt31MEdiEPvZBA39ZKUbVKXFEVKaqrWpfTp2DgjvKOinfBxJ6ly1QTOjtELe+VqOGfw7xzk7bTB5Zo6g2ausDCv2rllHiFYnYGAU7hrrTs+JOURsuGdGXSmrxBQY2Gx9Zv1bKm97a0tCola1eo6AYR6qFNII8QAx28cbywtyvQIYHtcP747Wp3j0y2+52n1+zVAkEh2IGFLVHYpuDlST3TsNxAKW9NftFpQag+rtTTuXFI0aFYaXIGge9jY59JvCin26iiW1CmiV6qZUEVCez1ZyMYG/TpLO/LlFiGY1GZfddqjl18DpbPdyPLrH7OUOv3mrOdXaPryRp9/OcYHSAUmnRprQ4pVajTqNRrVOz1gkAEg4xnoD5Ym7dUKIvLRGpqlKvblmRRhGrjT2ZZR4AFv9OZZf2WoYYfe4ckuO1qYYnqTvvPG85ZXKVKLP2tMgoXqVCMZBZOuwYDBgEbwJGVralUVFuadSsaqppA7EhlFRlXYE4THj+sugkHaWFZqqPW0Dsy5GDqdtX4S2kd0Dw8cCTggCIiAYxGJmIBjEYmYgCYImYgEbb8BtqdZq6UKa1W95woDH5yRxMxB6231MYjEzEHgmMTMQDGJmIgCIiAIiIAiIgCIiAIiIAjERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQBERAEREAREQD//Z" },
                    new Game {GameName = "Pokemon", GameShortDescription = "Collectible card game based on Nintendo's Pokémon franchise of video games and anime", GameLongDescription = "Collectible card game based on Nintendo's Pokémon franchise of video games and anime.Players assume the role of a Pokémon trainer and use their Pokémon to battle their opponents'. Players play Pokémon to the field and attack their opponent's Pokémon. A Pokémon that has sustained enough damage is knocked out, and the player who knocked it out draws a Prize card. There are usually six Prize cards, and the primary win condition is to draw all of them. Other ways to win are by knocking out all the Pokémon the opponent has on the field such that the opponent has none left, or if at the beginning of their opponent's turn there are no cards left to draw in the opponent's deck.", GameImageUrl = "data:image/png;base64,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", GameIsGameOfTheWeek = false, GameImageThumbnailURL = "data:image/png;base64,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" },
                };

                foreach (Game g in games)
                {
                    context.Games.Add(g);
                }
                context.SaveChanges();
            }
            if (!context.Formats.Any())
            {
                var formats = new Format[]
                {
                new Format {FormatName = "Standard", FormatDescription="Last two years of magic starting in Sept.", FormatLink="https://magic.wizards.com/en/content/standard-formats-magic-gathering", GameID=1},
                new Format {FormatName = "Modern", FormatDescription="Last ten years of magic", FormatLink="https://magic.wizards.com/en/game-info/gameplay/formats/modern", GameID=1},
                new Format {FormatName = "Standard", FormatDescription="Last two years of Pokemon starting in July", FormatLink="https://www.pokemon.com/us/pokemon-news/2019-season-pokemon-tcg-format-rotation/", GameID=2}
                };

                foreach (Format f in formats)
                {
                    context.Formats.Add(f);
                }
                context.SaveChanges();
            }
            if (!context.Tournaments.Any())
            {
                var tournaments = new Tournament[]
                {
                new Tournament {TournamentName = "Friday Night Magic",
                    TournamentDescription ="Player Magic Every Friday",
                    GameID = 1,
                    TournamentFee = 4.95M,
                    TournamentStartTime = new DateTime(2020, 1, 1, 18, 30, 0),
                    TournamentGame = context.Games.Where(p => p.GameID == 1).FirstOrDefault(),
                    TournamentFormat = context.Formats.Where(p => p.FormatID == 1).FirstOrDefault(),
                },
                };

                foreach (Tournament t in tournaments)
                {
                    context.Tournaments.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}
