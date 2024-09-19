using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests;

public record AddDeckRequest([Required] string Name);
