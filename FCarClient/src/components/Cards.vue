<template>
  <div>
    <h2>Cards for Deck: {{ deckId }}</h2>
    <div v-if="loading">Loading cards...</div>
    <div v-if="error">{{ error }}</div>
    <ul v-if="cards.length > 0">
      <li v-for="card in cards" :key="card.id">
        {{ card.front }} - {{ card.back }}
      </li>
    </ul>
    <button @click="$emit('close')">Back to Decks</button>
  </div>
</template>

<script>
export default {
  props: {
    deckId: {
      type: String, 
      required: true
    }
  },
  data() {
    return {
      cards: [],
      loading: false,
      error: null
    };
  },
  methods: {
    fetchCards() {
      this.loading = true;
      this.error = null;

      fetch(`https://localhost:7287/deck/${this.deckId}/cards`)
        .then(response => response.json())
        .then(data => {
          this.cards = data;
          this.loading = false;
        })
        .catch(err => {
          this.error = 'Failed to load cards';
          this.loading = false;
        });
    }
  },
  mounted() {
    this.fetchCards();
  }
}
</script>
