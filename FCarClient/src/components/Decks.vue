<template>
  <div>
    <div class="deck-container" v-if="!selectedDeck">
      <div v-for="deck in decks" :key="deck.id" class="deck-card" @click="openDeck(deck)">
        {{ deck.name }}
      </div>
    </div>

    <div v-if="selectedDeck">
      <cards :deckId="selectedDeck.id" @close="closeDeck" />
    </div>

    <div>
      <add-deck @refreshDecks="fetchDecks" />
    </div>
  </div>
</template>

<script>
import AddDeck from './AddDeck.vue';
import Cards from './Cards.vue';

export default {
  components: { AddDeck, Cards },
  data() {
    return {
      decks: [],
      selectedDeck: null
    };
  },
  methods: {
    fetchDecks() {
      fetch('https://localhost:7287/deck')
        .then(response => response.json())
        .then(data => {
          this.decks = data;
        });
    },
    openDeck(deck) {
      this.selectedDeck = deck;
    },
    closeDeck() {
      this.selectedDeck = null;
    }
  },
  mounted() {
    this.fetchDecks();
  },
};
</script>

<style scoped>
.deck-container {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
}

.deck-card {
  background-color: #18a14c;
  border-radius: 8px;
  padding: 20px;
  text-align: center;
  width: 150px;
  height: 100px;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
  transition: transform 0.3s ease;
}

.deck-card:hover {
  transform: scale(1.05);
}
</style>