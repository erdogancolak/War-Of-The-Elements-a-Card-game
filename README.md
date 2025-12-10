<img width="1585" height="888" alt="DeckBuilder1" src="https://github.com/user-attachments/assets/6dc4d4ed-e4ab-46db-bff2-d50efcf0279e" /># ⚔️ War Of The Elements: Card Strategy Game

![Unity](https://img.shields.io/badge/Unity-6000.0.29f1-000000?style=flat&logo=unity)
![C#](https://img.shields.io/badge/C%23-Scripting-239120?style=flat&logo=c-sharp)
![Status](https://img.shields.io/badge/Status-In%20Development-orange)

> A turn-based strategy card game featuring a complex elemental system, custom deck-building logic, and data-driven architecture using **ScriptableObjects**.

---

## 📖 About The Project

**War Of The Elements** is a digital card game where players build their own decks using 8 distinct elemental classes and battle against an AI opponent. The project was built to demonstrate **scalable game architecture** and **advanced UI management** in Unity.

The core focus of this project is **Data-Driven Design**. By leveraging **ScriptableObjects**, all card data (Stats, Art, Mana Cost, Element Type) is decoupled from the code, making the system easy to expand and balance.

---

## 🎮 Key Features

### 1. Advanced Deck Building System
I designed a logic-based deck creation system with specific constraints to ensure gameplay balance:
* **Deck Size:** 40 Cards total.
* **Element Limit:** Maximum **15 cards** from a single element type.
* **RNG Pool:** Players select an element, but the specific cards are drawn from a randomized pool of 20 variations per element.
* **Mana Economy:** Strategic resource management system.

### 2. The 8 Elemental Classes (Mechanics)
Each element has a unique passive ability that defines its playstyle:

| Element | Role | Special Ability |
| :--- | :--- | :--- |
| **🌱 Nature** | Support | **Buff:** Increases the **Health** of the ally card on the right by **+2**. |
| **⚡ Lightning** | Speed | **Quick Attack:** If Attack Power > Enemy Health, the enemy **cannot counter-attack**. |
| **🔥 Fire** | Buffer | **Buff:** Increases the **Attack Power** of the ally card on the right by **+1**. |
| **❄️ Ice** | Debuffer | **Freeze:** Reduces the opposing enemy's **Attack Power** by **-1**. |
| **👑 Crown** | Healer | **Lifesteal:** If it hits the opponent, it **heals your Tower** equal to the damage dealt. |
| **🧙‍♂️ Mage** | Burst | **Spell:** Deals **2 damage** instantly at the combat start. If the enemy dies, no counter-attack occurs. |
| **🌊 Ocean** | Overwhelm | **Trample:** If Attack Power > Enemy Health, the **excess damage** hits the Enemy Tower. |
| **👻 Ghost** | Elusive | **Evasion:** Can only be blocked or damaged by another **Ghost** card. |

---

## ⚙️ Technical Highlights

* **ScriptableObject Architecture:** Used for managing card databases and game configurations efficiently.
* **Custom AI Logic:** Implemented an AI opponent that evaluates the board state and plays cards strategically based on mana availability.
* **Pixel Art UI:** All UI elements and icons were personally designed and integrated into Unity's canvas system.
* **Audio System:** Complete audio feedback loop for card interactions, combat effects, and UI clicks.

---

## 📸 Screenshots & Gameplay

<div align="center">
  <a href="https://www.linkedin.com/posts/erdogancolak_de%C4%9Ferli-linkedin-ba%C4%9Flant%C4%B1lar%C4%B1m-unity-kullanarak-activity-7279802233024638976-OCKT?utm_source=share&utm_medium=member_desktop&rcm=ACoAAD3OeJABrUqzthwfxiLdE5p2nSauQEkOXlc" target="_blank">
    <img src="https://img.shields.io/badge/Watch_Gameplay_Video-0077B5?style=for-the-badge&logo=linkedin&logoColor=white" alt="Watch Gameplay"/>
  </a>
</div>


| Deck Builder | Combat Phase |
| :---: | :---: |
| <img width="100%" alt="DeckBuilder1" src="https://github.com/user-attachments/assets/f6d624b0-c42a-43ed-abf3-a90ecf014c49" /> | <img width="100%" alt="Gameplay1" src="https://github.com/user-attachments/assets/ee57376b-0368-42ef-b8b7-d4f57fb88aee" /> |
| <img width="100%" alt="DeckBuilder2" src="https://github.com/user-attachments/assets/2de195a7-8018-4d22-b9be-487cf17de8bc" /> | <img width="100%" alt="Gameplay2" src="https://github.com/user-attachments/assets/1102d28b-eb28-47ea-8380-db902369b816" /> |

---

## 🚀 Future Roadmap

- [ ] Implementing Multiplayer support via **Photon PUN 2**.
- [ ] Adding new card synergies and combo mechanics.
- [ ] improving AI difficulty levels using Minimax algorithm.

---

### 👨‍💻 Developer
Developed by **[Erdoğan Çolak](https://www.linkedin.com/in/erdogancolak/)**
*Feel free to contact me for collaboration or feedback!*
