using Microsoft.AspNetCore.Mvc;

namespace DesafioAda.Model;

public record CardByIdDto([FromRoute] Guid Id);
