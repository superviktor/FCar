using System.ComponentModel.DataAnnotations;

namespace WebApi.Requests;

public record AddCardRequest([Required] string Front, [Required] string Back);
